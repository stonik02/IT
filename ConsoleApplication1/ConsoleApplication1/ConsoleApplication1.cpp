#include <iostream>
#include <cmath>

using namespace std;

long double fact(int N)
{
    if (N == 0) return 1;
    else return N * fact(N - 1);
}

int main()
{
    double x, sum = 0.0;
    int n;

    

    cout << "n: = ";
    cin >> n;
    cout << "x= : ";
    cin >> x;

    for (int i = 0; i < n; i++)
    {
        double term = pow(x, 2 * i) / fact(2 * i);
        sum += term;
    }

    cout << "Sum of the series is " << sum << endl;

    return 0;
}

