#include <bits/stdc++.h>

using namespace std;

string ltrim(const string &);
string rtrim(const string &);
vector<string> split(const string &);

/*
 * Complete the 'bomberMan' function below.
 *
 * The function is expected to return a STRING_ARRAY.
 * The function accepts following parameters:
 *  1. INTEGER n
 *  2. STRING_ARRAY grid
 */

void detonate(vector<string>& grid, const vector<string>& previous_grid)
{
    size_t r{ grid.size() };
    size_t c{ grid[0].size() };

    for (int i = 0; i < r; ++i)
    {
        for (int j = 0; j < c; ++j)
        {
            if (previous_grid[i][j] == 'O')
            {
                grid[i][j] = '.';

                if (i + 1 < r)
                    grid[i + 1][j] = '.';

                if (i - 1 >= 0)
                    grid[i - 1][j] = '.';

                if (j + 1 < c)
                    grid[i][j + 1] = '.';

                if (j - 1 >= 0)
                    grid[i][j - 1] = '.';
            }
        }
    }
}

vector<string> bomberMan(int n, vector<string> grid)
{
    vector<string> initial_grid{ grid };
    vector<string> full_of_bombs{ grid };
    vector<string> pattern_a;

    size_t r{ grid.size() };
    size_t c{ grid[0].size() };

    for (int i = 0; i < r; ++i)
        for (int j = 0; j < c; ++j)
            grid[i][j] = 'O';

    for (int i = 0; i < r; ++i)
        for (int j = 0; j < c; ++j)
            full_of_bombs[i][j] = 'O';

    detonate(grid, initial_grid);

    pattern_a = grid;

    for (int i = 0; i < r; ++i)
        for (int j = 0; j < c; ++j)
            grid[i][j] = 'O';

    detonate(grid, pattern_a);

    int k{ n % 4 };

    if (n == 1)
        return initial_grid;

    if (k == 0 || k == 2)
        return full_of_bombs;
    else if (k == 3)
        return pattern_a;

    return grid;
}
