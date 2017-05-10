#include "../../Function/TFunction.h"
#include "../../SearchData/TavlTree.h"

typedef struct TavlTree TSearchData;

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
	TSearchData *pData;
	nodeptr root;

public:
	IMethod() {	}
	IMethod(int _MaxNumOfTrials, double _Eps, TTask *_pTask, TSearchData *_pData) {	}
	~IMethod() { }

	virtual void RenewSearchData(double _x) = 0;
	virtual TPoint CalculateOptimum() = 0;
};