#pragma once

#define Error_1000 1000 // incorrect brackets
#define Error_1001 1001 // incorrect string
#define Error_1002 1002 // incorrect functions
#define Error_1003 1003 // divide by zero
#define Error_1004 1004 // logarithm <=0

#include <string>
#include <stack>

class TFunction {
 private:
	std::string Infix;
	std::string Postfix;

    template<typename ValType>
    ValType get(std::stack<ValType> &);
    
    std::string CutInfix(std::string);
    void DeleteSpace(std::string);/* Удаление пробелов из строки*/
    bool CheckBrackets(std::string&);/*Проверка скобок. Первый параметр - входная строка.*/
    int Priority(char);/*Получить приоритет операции*/
    std::string InfiToPost(void);/* Перевод арифметического выражения инфиксного вида
 в постфиксный. Выполняется с помощью предложенного алгоритма со стеком*/
    double CalcBin(double, double, char);/* Подсчет значения бинарной операции, определяемой char,
и двух операндов double. Порядок записи double важен.*/
    double StandartFunc(double,char);
    double CalcPost(double);/*Подсчет значения арифметического выражения, представленного
в постфиксной форме*/
 public:
    TFunction(std::string);
	TFunction();
    ~TFunction() {};
	void SetFunction(std::string);
	std::string GetFunction(void);
    double Calculate(const double&);
};

