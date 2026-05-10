using System;
using System.Collections.Generic;

class BankersAlgorithm
{
static void Main()
{
Console.Write("Number of processes: ");
int n = int.Parse(Console.ReadLine());
Console.Write("Number of resource types: ");
int m = int.Parse(Console.ReadLine());

int[,] allocation = new int[n, m];
int[,] maxDemand = new int[n, m];
int[] available = new int[m];

Console.WriteLine("Enter allocation matrix:");
for (int i = 0; i < n; i++)
{
Console.Write($"P{i + 1}: ");
string[] row = Console.ReadLine().Split(' ');
for (int j = 0; j < m; j++)
allocation[i, j] = int.Parse(row[j]);
}

Console.WriteLine("Enter maximum demand matrix:");
for (int i = 0; i < n; i++)
{
Console.Write($"P{i + 1}: ");
string[] row = Console.ReadLine().Split(' ');
for (int j = 0; j < m; j++)
maxDemand[i, j] = int.Parse(row[j]);
}

Console.Write("Enter available resources: ");
string[] avail = Console.ReadLine().Split(' ');
for (int j = 0; j < m; j++)
available[j] = int.Parse(avail[j]);

int[,] need = new int[n, m];
for (int i = 0; i < n; i++)
for (int j = 0; j < m; j++)
need[i, j] = maxDemand[i, j] - allocation[i, j];

bool[] finished = new bool[n];
int[] work = (int[])available.Clone();
List<int> safeSeq = new List<int>();

int count = 0;
while (count < n)
{
bool found = false;
for (int i = 0; i < n; i++)
{
if (!finished[i])
{
bool canAllocate = true;
for (int j = 0; j < m; j++)
if (need[i, j] > work[j])
{ canAllocate = false; break; }

if (canAllocate)
{
for (int j = 0; j < m; j++)
work[j] += allocation[i, j];

finished[i] = true;
safeSeq.Add(i + 1);
found = true;
count++;
}
}
}
if (!found) break;
}

if (safeSeq.Count == n)
{
Console.Write("Safe Sequence: ");
for (int k = 0; k < safeSeq.Count; k++)
{
Console.Write($"P{safeSeq[k]}");
if (k < safeSeq.Count - 1) Console.Write(" -> ");
}
Console.WriteLine(" System is in a safe state.");
}
else
{
Console.WriteLine("System is NOT in a safe state.");
}
}
}
