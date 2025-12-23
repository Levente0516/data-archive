#include <iostream>

using namespace std;

int main()
{
	string str = "abc#cba";

    int n = str.length();

	for (int i = 0; i < n; i++)
	{
		if (str[i] == '#')
        {
            int left = i - 1;
            int right = i + 1;

            while (left >= 0 && right < n)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                left--;
                right--;
            }

            return left == -1 && right == n;
        }
	}

	return false;
}
