Console.WriteLine("Введите количество фишек на каждом месте через пробел:");
string[] input = Console.ReadLine().Split(',');
int[] chips = new int[input.Length];
for (int i = 0; i < input.Length; i++)
{
    chips[i] = int.Parse(input[i]);
}
int totalChips = 0;
foreach (int chip in chips)
{
    totalChips += chip;
}
int target = totalChips / chips.Length;
int minSteps = 0;
while(true)
{
    int maxVal = chips.Max();
    int minWay = chips.Length;
    int[] newPos = new int[chips.Length];
    for (int i = 0; i < chips.Length; i++)
    {
        if(chips[i] < target)
        {
            
            for (int j = 0; j < chips.Length; j++)  
            {
                if(chips[j] == maxVal && Math.Abs(i - j) < minWay)
                {
                    minWay = Math.Abs(i - j);
                    for(int k = 0; k < chips.Length; k++)
                    {
                        if (k == i)
                        {
                            newPos[k] = chips[i] + 1;
                        }
                        else if (k == j)
                        {
                            newPos[k] = chips[j] - 1;
                        }
                        else
                        {
                            newPos[k] = chips[k];
                        }
                    }
                }
                if(chips[j] == maxVal && Math.Abs(chips.Length - j) + i < minWay)
                {
                    minWay = Math.Abs(chips.Length - j) + i;
                    for (int k = 0; k < chips.Length; k++)
                    {
                        if (k == i)
                        {
                            newPos[k] = chips[i] + 1;
                        }
                        else if (k == j)
                        {
                            newPos[k] = chips[j] - 1;
                        }
                        else
                        {
                            newPos[k] = chips[k];
                        }
                    }
                }
                if (chips[j] == maxVal && Math.Abs(chips.Length - i - 1) + j < minWay)
                {
                    minWay = Math.Abs(chips.Length - i - 1) + j;
                    for (int k = 0; k < chips.Length; k++)
                    {
                        if (k == i)
                        {
                            newPos[k] = chips[i] + 1;
                        }
                        else if (k == j)
                        {
                            newPos[k] = chips[j] - 1;
                        }
                        else
                        {
                            newPos[k] = chips[k];
                        }
                    }
                }
            }
        }
    }
    minSteps += minWay;
    chips = newPos;
    bool ready = true;
    for(int i = 0; i < chips.Length; i++)
    {
        if (chips[i] != target)
        {
            ready = false;
            break;
        }
    }
    if(ready)
    {
        break;
    }
}
Console.WriteLine($"Минимальное количество ходов: {minSteps}");