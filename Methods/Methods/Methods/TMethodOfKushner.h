#include "IMethod.h"

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


			for (int i = 0; i<pTask->maxOfIterations;i++)
			{
				if (z[i]<minZ) 
					minZ = z[i];
			}

			for (size_t j = 1; j <= i; j++)
			{
				R[j - 1] = -4 * ((minZ - Y - z[j - 1])*(minZ - Y - z[j]))/(x[j]-x[j-1]);

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