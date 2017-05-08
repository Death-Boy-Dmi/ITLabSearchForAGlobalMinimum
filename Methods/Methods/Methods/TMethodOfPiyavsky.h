#pragma once

#include "IMethod.h"
#include <vector>

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

public:

	TMethodOfPiyavsky(TTask *_pTask/*, TSearchData *_pData*/)
	{
		pTask = _pTask;
		//pData = _pData;
		TFunction _func(pTask->str_function);
		function = _func;
		M = pTask->r;
	}

	double f(double x)
	{
		/*return (x/4)*cos(x);*/
		return function.Calculate(x);
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
		currentPoint= getNextPoint(pTask->xl,pTask->xr);
		insertPointInData(x, currentPoint);
		currPoint = makePoint(currentPoint);
		updateOptimum(currPoint, result);

		int i;
		int j = 0;
		double tempJ = 0;
		double tempX;
		double tempChara;
		double gotAccuracy = pTask->xr - pTask->xl;
		for (i = 1;i < Iterations;++i)
		{
			tempJ = 0;
			currentChara= getIntervalCharacteristic(x[0],x[1]);
			for (j = 1;j < x.size()-1;++j)
			{
				tempChara = getIntervalCharacteristic(x[j],x[j+1]);
				if (tempChara > currentChara)
				{
					currentChara = tempChara;
					tempJ = j;
					gotAccuracy = x[tempJ + 1] - x[tempJ];
				}
			}
			tempX= getNextPoint(x[tempJ],x[tempJ+1]);
			insertPointInData(x, tempX);
			currPoint = makePoint(tempX);
			updateOptimum(currPoint, result);
			if (pTask->eps >= gotAccuracy)
				break;
		}
		return result;
	}
};
