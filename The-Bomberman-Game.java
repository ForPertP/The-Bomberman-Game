import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.function.*;
import java.util.regex.*;
import java.util.stream.*;
import static java.util.stream.Collectors.joining;
import static java.util.stream.Collectors.toList;

class Result {

   public static void detonate(List<String> currentGrid, List<String> previousGrid) {
        int rows = currentGrid.size();
        int cols = currentGrid.get(0).length();

        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                if (previousGrid.get(i).charAt(j) == 'O') {
                    currentGrid.set(i, currentGrid.get(i).substring(0, j) + "." + currentGrid.get(i).substring(j + 1));
                    if (i + 1 < rows)
                        currentGrid.set(i + 1, currentGrid.get(i + 1).substring(0, j) + "." + currentGrid.get(i + 1).substring(j + 1));
                    if (i - 1 < rows && i - 1 >= 0)
                        currentGrid.set(i - 1, currentGrid.get(i - 1).substring(0, j) + "." + currentGrid.get(i - 1).substring(j + 1));
                    if (j + 1 < cols)
                        currentGrid.set(i, currentGrid.get(i).substring(0, j + 1) + "." + currentGrid.get(i).substring(j + 2));
                    if (j - 1 < cols && j - 1 >= 0)
                        currentGrid.set(i, currentGrid.get(i).substring(0, j - 1) + "." + currentGrid.get(i).substring(j));
                }
            }
        }
    }

    
    /*
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING_ARRAY grid
     */
}


public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));
        BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(System.getenv("OUTPUT_PATH")));

        String[] firstMultipleInput = bufferedReader.readLine().replaceAll("\\s+$", "").split(" ");

        int r = Integer.parseInt(firstMultipleInput[0]);

        int c = Integer.parseInt(firstMultipleInput[1]);

        int n = Integer.parseInt(firstMultipleInput[2]);

        List<String> grid = IntStream.range(0, r).mapToObj(i -> {
            try {
                return bufferedReader.readLine();
            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }
        })
            .collect(toList());

        List<String> result = Result.bomberMan(n, grid);

        bufferedWriter.write(
            result.stream()
                .collect(joining("\n"))
            + "\n"
        );

        bufferedReader.close();
        bufferedWriter.close();
    }
}
