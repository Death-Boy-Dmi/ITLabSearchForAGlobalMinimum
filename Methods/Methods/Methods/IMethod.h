#include "../../Function/TFunction.h"

struct TPoint
{
	double x;
	double y;
};
struct TTask
{
	std::string str_function;
	double xl;
	double xr;
	double eps;
	int maxOfIterations;
	int r;
};

class IMethod
{
protected:
	/// ћаксимальное число испытаний
	int MaxNumOfTrials;
	/// точность решени€ задачи
	double Epsilon;
	/// ”казатель на решаемую задачу
	TTask *pTask;
	/// ”казатель на матрицу состо€ни€ поиска
	/*TSearchData *pData;*/

public:
	IMethod() {	}
	IMethod(int _MaxNumOfTrials, double _Eps, TTask *_pTask/*, TSearchData *_pData*/) {	}
	~IMethod() { }

	//virtual void RenewSearchData() = 0;

	virtual TPoint CalculateOptimum() = 0;
};