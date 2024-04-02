class Program
{
    static void Main(string[] args)
    {
        // this connects the txt file so it can be read and analyzed
        string table = @"C:\Users\Admin\source\repos\Assigment 2\Assigment 2\table1.txt";

        // stores txt elements into a 2d list
        List<string[]> arrayList = new List<string[]>();

        int maxCells = 0;
        int rowWithMaxCells = 0;

        try
        {
            using (StreamReader read = File.OpenText(table))
            {
                string text;

                // reads the file
                while ((text = read.ReadLine()) != null)
                {
                    // splits text elements by commas
                    string[] arrayNum = text.Split(',');

                    // adds each element after splitted into the list
                    arrayList.Add(arrayNum);
                }
            }

            // first row is automatically not a seatable cell
            Console.WriteLine("Row 1: 0 Seatable Cells");

            // loops the rows of the list starting with the second row, (index 1)
            for (int row = 1; row < arrayList.Count - 1; row++)
            {
                int seatable = 0;
                // defines the current row of the 2d list
                // defines the above row of the current row
                // defines the below row of current row
                string[] currentArray = arrayList[row];
                string[] beforeArray = arrayList[row - 1];
                string[] afterArray = arrayList[row + 1];

                // defines the values inside each row
                for (int num = 1; num < currentArray.Length - 1; num++)
                {
                    // defines the value in the top row of current row on the same index value
                    int upCell = int.Parse(beforeArray[num]);
                    // defines the value in the bottom row of current array on the same index value
                    int downCell = int.Parse(afterArray[num]);
                    // defines the value in the current row
                    int currentCell = int.Parse(currentArray[num]);
                    // defines the after value of the value in the current row
                    int afterCell = int.Parse(currentArray[num + 1]);
                    // defines the before value of the value in the current row
                    int beforeCell = int.Parse(currentArray[num - 1]);

                    // set rules to determine if value is a seatable cell
                    if ((currentCell < afterCell && currentCell < beforeCell && currentCell > upCell && currentCell > downCell) ||
                        (currentCell > afterCell && currentCell > beforeCell && currentCell < upCell && currentCell < downCell))
                    {
                        // counts the amount of seatable cells in current row every loop
                        seatable++;
                    }
                }

                Console.WriteLine($"Row {row + 1}: {seatable} Seatable cells");

                // determines the row with the most seatable cell and it's value
                if (seatable > maxCells)
                {
                    maxCells = seatable;
                    rowWithMaxCells = row + 1;
                }
            }

            // defines the last row of the 2d list
            int finalArray = arrayList.Count;
            Console.WriteLine($"Row {finalArray}: 0 seatable Cells");
            Console.WriteLine($"Row with the most seatable cells: Row {rowWithMaxCells} with {maxCells} seatable cells");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found");
        }
        catch (IOException)
        {
            Console.WriteLine($"An I/O error occurred");
        }
        catch (Exception)
        {
            Console.WriteLine($"unexpected error occurred");
        }
    }
}

