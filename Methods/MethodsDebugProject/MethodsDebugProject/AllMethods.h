#pragma once
#include <vector>
#include <map>
#include "Headers\IMethod.h"

class TMethodOfGlobalSearch : public IMethod
{
protected:
	TFunction function;
public:

	TMethodOfGlobalSearch(TTask *_pTask, TSearchData *_pData)
	{
		pTask = _pTask;
		pData = _pData;
		TFunction _func(pTask->str_function);
		function = _func;
	}

	double f(double x)
	{
		/*return (x/4)*cos(x);*/
		return function.Calculate(x);
	}

	~TMethodOfGlobalSearch() { }

	virtual void RenewSearchData(double _x)
	{
		double _y = f(_x);
		TPoint tmp;
		tmp.x = _x; tmp.y = _y;
		pData->insert(tmp, root);
	}

	virtual TPoint CalculateOptimum()
	{
		TPoint result;
		double m = 1;
		double maxM = 0;
		double* M = new double[pTask->maxOfIterations];

		double* x = new double[pTask->maxOfIterations];
		double* R = new double[pTask->maxOfIterations];
		double maxR = 0;
		unsigned int maxIR = 0;

		double minF;
		double minX;

		x[0] = pTask->xl; x[1] = pTask->xr;

		if (f(x[0]) < f(x[1]))
		{
			minF = f(x[0]);
			minX = x[0];
		}
		else
		{
			minF = f(x[1]);
			minX = x[1];
		}

		for (size_t i = 1; i < pTask->maxOfIterations; i++)
		{
			for (size_t j = 0; j < i; j++)
				for (size_t l = 0; l < i - j; l++)
					if (x[l] > x[l + 1])
						std::swap(x[l], x[l + 1]);

			for (size_t j = 1; j <= i; j++)
			{
				M[j - 1] = (abs(f(x[j]) - f(x[j - 1]))) / (x[j] - x[j - 1]);
				if (M[j - 1] > maxM)
				{
					maxM = M[j - 1];
				}
			}

			if (maxM > 0)
			{
				m = pTask->r*maxM;
			}

			for (size_t j = 1; j <= i; j++)
			{
				R[j - 1] = m*(x[j] - x[j - 1]) + (pow((f(x[j]) - f(x[j - 1])), 2)) / (m*(x[j] - x[j - 1])) - 2 * (f(x[j]) + f(x[j - 1]));

				if (R[j - 1] > maxR)
				{
					maxR = R[j];
					maxIR = j;
				}
			}

			if (abs(x[maxIR] - x[maxIR - 1]) < pTask->eps)
			{
				break;
			}

			x[i + 1] = 0.5*(x[maxIR] + x[maxIR - 1]) - 0.5*(f(x[maxIR]) - f(x[maxIR - 1])) / m;
			RenewSearchData(x[i + 1]);

			if (f(x[i + 1]) < minF)
			{
				minF = f(x[i + 1]);
				minX = x[i + 1];
			}

		}
		result.x = minX;
		result.y = minF;
		return result;
	}
};

class TMethodOfPiyavsky : public IMethod
{
protected:
	double M;
	TFunction function;
	double getNextPoint(double LB, double RB)
	{
		return 0.5*(RB + LB) - 0.5*(f(RB) - f(LB)) / M;
	}
	double getIntervalCharacteristic(double LB, double RB)
	{
		return 0.5*M*(RB - LB) - 0.5*(f(RB) + f(LB));
	}
	void updateOptimum(TPoint& CheckingPoint, TPoint& Optimum)
	{
		if (CheckingPoint.y < Optimum.y)
		{
			Optimum.x = CheckingPoint.x;
			Optimum.y = CheckingPoint.y;
		}
	}
	TPoint& makePoint(double x)
	{
		TPoint tp;
		tp.x = x;
		tp.y = f(x);
		return tp;
	}
	void insertPointInData(std::vector<double>& Data, double x)
	{
		int j = 0;
		while (x > Data[j] && j<Data.size() - 1)
			j++;
		Data.insert(Data.begin() + j, x);
	}

	virtual void RenewSearchData(double _x)
	{
		double _y = f(_x);
		TPoint tmp;
		tmp.x = _x; tmp.y = _y;
		pData->insert(tmp, root);
	}
	double f(double x)
	{
		return function.Calculate(x);
	}

public:

	TMethodOfPiyavsky(TTask *_pTask, double _M, TSearchData *_pData)
	{
		pTask = _pTask;
		pData = _pData;
		TFunction _func(pTask->str_function);
		function = _func;
		M = _M;
	}
	~TMethodOfPiyavsky() { }

	virtual TPoint CalculateOptimum()
	{
		TPoint result;
		TPoint currPoint;
		std::vector<double> x;
		int Iterations = pTask->maxOfIterations;
		double currentChara = 0;
		double currentPoint = 0;

		x.push_back(pTask->xl);
		result = makePoint(pTask->xl);
		x.push_back(pTask->xr);
		currPoint = makePoint(pTask->xr);
		updateOptimum(currPoint, result);

		currentChara = getIntervalCharacteristic(pTask->xl, pTask->xr);
		currentPoint = getNextPoint(pTask->xl, pTask->xr);
		insertPointInData(x, currentPoint);
		currPoint = makePoint(currentPoint);
		updateOptimum(currPoint, result);

		int i;
		int j = 0;
		double tempJ = 0;
		double tempX;
		double tempChara;
		double gotAccuracy = pTask->xr - pTask->xl;
		for (i = 1; i < Iterations; ++i)
		{
			tempJ = 0;
			currentChara = getIntervalCharacteristic(x[0], x[1]);
			for (j = 1; j < x.size() - 1; ++j)
			{
				tempChara = getIntervalCharacteristic(x[j], x[j + 1]);
				if (tempChara > currentChara)
				{
					currentChara = tempChara;
					tempJ = j;
					gotAccuracy = x[tempJ + 1] - x[tempJ];
				}
			}
			tempX = getNextPoint(x[tempJ], x[tempJ + 1]);
			insertPointInData(x, tempX);
			RenewSearchData(tempX);
			currPoint = makePoint(tempX);
			updateOptimum(currPoint, result);
			if (pTask->eps >= gotAccuracy)
				break;
		}
		return result;
	}
};

class TMethodOfKushner : public IMethod
{
protected:
	TFunction function;
	double Y; // parametr metoda ot 0 do 1
public:

	TMethodOfKushner(TTask *_pTask, TSearchData *_pData)
	{
		pTask = _pTask;
		pData = _pData;
		TFunction _func(pTask->str_function);
		function = _func;
		Y = _pTask->r;
	}

	double f(double x)
	{
		return function.Calculate(x);
	}

	~TMethodOfKushner() { }

	virtual void RenewSearchData(double _x)
	{
		double _y = f(_x);
		TPoint tmp;
		tmp.x = _x;
		tmp.y = _y;
		pData->insert(tmp, root);
	}

	virtual TPoint CalculateOptimum()
	{
		TPoint result;
		double minZ;
		double maxZ;
		double minX;

		double* z = new double[pTask->maxOfIterations];

		double* x = new double[pTask->maxOfIterations];
		double* R = new double[pTask->maxOfIterations];

		double maxR = 0;
		unsigned int maxIR = 0;



		x[0] = pTask->xl;
		x[1] = pTask->xr;

		z[0] = f(x[0]);
		z[1] = f(x[1]);

		if (z[0] < z[1])
		{
			minZ = z[0];
			minX = x[0];
		}
		else
		{
			minZ = f(x[1]);
			minX = z[1];
		}

		for (size_t i = 1; i < pTask->maxOfIterations; i++)
		{
			for (size_t j = 0; j < i; j++)
				for (size_t l = 0; l < i - j; l++)
					if (x[l] > x[l + 1])
						std::swap(x[l], x[l + 1]);


			for (int i = 0; i<pTask->maxOfIterations; i++)
			{
				if (z[i]<minZ)
					minZ = z[i];
			}

			for (size_t j = 1; j <= i; j++)
			{
				R[j - 1] = -4 * ((minZ - Y - z[j - 1])*(minZ - Y - z[j])) / (x[j] - x[j - 1]);

				if (R[j - 1] > maxR)
				{
					maxR = R[j];
					maxIR = j;
				}
			}

			if (abs(x[maxIR] - x[maxIR - 1]) < pTask->eps)
			{
				break;
			}

			x[i + 1] = x[maxIR - 1] + ((x[maxIR] - x[maxIR - 1])*(minZ - Y - z[maxIR - 1])) / (2 * (minZ - Y) - z[maxIR] - z[maxIR - 1]);
			RenewSearchData(x[i + 1]);
			z[i + 1] = f(x[i + 1]);

			if (z[i + 1] < minZ)
			{
				minZ = z[i + 1];
				minX = x[i + 1];
			}

		}

		result.x = minX;
		result.y = minZ;
		return result;
	}
};