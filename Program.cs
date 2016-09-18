using System;

public static class Program {
    private static void Merge(int[] a, int[] b, int[] c) {
        int n = a.Length, m = b.Length;
        int i = 0, j = 0;
        for (int k = 0; k < m + n; k++) {
            if (j >= m || i < n && a[i] < b[j]) {
                c[k] = a[i++];
            } else {
                c[k] = b[j++];
            }
        }
    }

    private static void MergeSort(int[] a, int s, int f) { // 's' for "start" and 'f' for "final"== the next after the last
        int n = f - s;
        if (n == 1) return;
        int n1 = n / 2, n2 = n - n1;
        MergeSort(a, s, s + n1);
        MergeSort(a, s + n1, f);
        int[] u = new int[n1];
        int[] v = new int[n2];
        int[] w = new int[n];
        for (int i = 0; i < n1; i++)
            u[i] = a[s + i];
        for (int i = 0; i < n2; i++)
            v[i] = a[s + n1 + i];
        Merge(u, v, w);
        for (int i = 0; i < n; i++)
            a[s + i] = w[i];
    }

    public static void MergeSort(int[] a) {
        MergeSort(a, 0, a.Length);
    }

    public static int BinarySearch(int[] a, int x, int s, int f) {
        int n = f - s;
            if (x == a[s + n/2]) {
                return a[s + n/2];
            } else if (x < a[s + n/2]) {
                return BinarySearch(a, x, s, s + n/2);
            } else if (x > a[s + n/2]) {
                return BinarySearch(a, x, s + n/2 + 1, f);
            }
        return 0;
    }

    public static int BinarySearch(int[] a, int x) {
        return BinarySearch(a, x, 0, a.Length);
    }

    public static void PrintArray(int[] a) {
        foreach (int i in a) {
            Console.Write($"{i} ");
        }
    }

    public static void Main (string[] args) {
        int x = 91;
        int[] a = new int[] {2, 4, 20, 333, 586, 77000, 91, 18, 1};
        PrintArray(a);
        MergeSort(a);
        Console.WriteLine("");
        PrintArray(a);
        int b = BinarySearch(a, x);
        Console.WriteLine("");
        Console.WriteLine(b);
    }
}
