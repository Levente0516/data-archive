#include <iostream>

using namespace std;

int main()
{
    string a[3] = {"Andras", "Bela", "Csaba"};

    for (int i = 2; i >= 0; i--)
    {
        cout << a[i] << " ";
    }
    cout << endl;
    return 0;
}
