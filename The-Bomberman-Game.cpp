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
