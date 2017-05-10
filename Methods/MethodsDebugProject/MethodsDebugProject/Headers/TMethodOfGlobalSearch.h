#include "IMethod.h"

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