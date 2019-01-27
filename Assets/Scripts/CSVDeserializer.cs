using System.Collections;
using System.Collections.Generic;
using System;

public class CSVFileReader
{
    private Queue _linesQueue;

    public CSVFileReader(string _pData)
    {
        string[] linesArray = _pData.Split('\n');

        _linesQueue = new Queue();
        foreach (string line in linesArray)
        {
            _linesQueue.Enqueue(line);
        }
        return;
    }

    public bool
    ReadRow(CSVRow _row)
    {
        int pos = 0;
        int rows = 0;

        if (_linesQueue.Count != 0)
        {
            _row.LineText = _linesQueue.Dequeue() as string;
        }
        else
        {
            _row.LineText = null;
        }


        if (String.IsNullOrEmpty(_row.LineText))
        {
            return false;
        }

        while (pos < _row.LineText.Length)
        {
            string value;

            // Special handling for quoted field
            if (_row.LineText[pos] == '"')
            {
                // Skip initial quote
                pos++;

                // Parse quoted value
                int start = pos;
                while (pos < _row.LineText.Length)
                {
                    // Test for quote character
                    if (_row.LineText[pos] == '"')
                    {
                        // Found one
                        pos++;

                        // If two quotes together, keep one
                        // Otherwise, indicates end of value
                        if (pos >= _row.LineText.Length || _row.LineText[pos] != '"')
                        {
                            pos--;
                            break;
                        }
                    }
                    pos++;
                }
                value = _row.LineText.Substring(start, pos - start);
                value = value.Replace("\"\"", "\"");
            }
            else
            {
                // Parse unquoted value
                int start = pos;
                while (pos < _row.LineText.Length && _row.LineText[pos] != ',')
                {
                    pos++;
                }
                value = _row.LineText.Substring(start, pos - start);
            }

            // Add field to list
            if (rows < _row.Count)
            {
                _row[rows] = value;
            }
            else
            {
                _row.Add(value);
            }

            rows++;

            // Eat up to and including next comma
            while (pos < _row.LineText.Length && _row.LineText[pos] != ',')
            {
                pos++;
            }

            if (pos < _row.LineText.Length)
            {
                pos++;
            }

        }

        // Delete any unused items
        while (_row.Count > rows)
        {
            _row.RemoveAt(rows);
        }

        // True if any row reads.
        return (_linesQueue.Count > 0);
    }

    public int NUM_ROW
    {
        get
        {
            return _linesQueue.Count - 1;
        }
    }

    public int NUM_COL
    {
        get
        {
            if(_linesQueue.Count == 0)
            {
                return 0;
            }
            else
            {
                string line = _linesQueue.Peek() as string;
                int cont = 0;
                foreach(char schar in line)
                {
                    if(schar == '0')
                    {
                        cont++;
                    }
                }

                return cont;
            }
        }
    }

}

public class CSVRow
       : List<string>
{
    public string LineText
    {
        get;
        set;
    }
}