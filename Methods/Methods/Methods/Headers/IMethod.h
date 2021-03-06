#include "TFunction.h"
#include "TavlTree.h"

typedef class TavlTree TSearchData;

struct TTask
{
	std::string str_function;
	double xl;
	double xr;
	double eps;
	int maxOfIterations;
};

class IMethod
{
protected:
	/// ������������ ����� ���������
	int MaxNumOfTrials;
	/// �������� ������� ������
	double Epsilon;
	/// ��������� �� �������� ������
	TTask *pTask;
	/// ��������� �� ������� ��������� ������
	TSearchData *pData;
	nodeptr root;

public:
	IMethod() {	}
	IMethod(int _MaxNumOfTrials, double _Eps, TTask *_pTask, TSearchData *_pData) {	}
	~IMethod() { }

	virtual void RenewSearchData(double _x) = 0;
	virtual TPoint CalculateOptimum() = 0;
};