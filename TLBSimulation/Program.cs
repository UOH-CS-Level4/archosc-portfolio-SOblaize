using System;
using System.Collections.Generic;

class TLBEntry {
    public int VPN;
    public int PPN;
}

class TLB {
    private List<TLBEntry> entries = new List<TLBEntry>();
    private const int capacity = 4;
    private int hits = 0;
    private int misses = 0;

    public void Translate(int vpn, int[] pageTable) {
        int? ppn = Lookup(vpn);

        if (ppn != null) {
            hits++;
            Console.WriteLine($"VPN {vpn} -> TLB HIT -> PPN {ppn}");
        } else {
            misses++;
            int newPPN = pageTable[vpn];
            Insert(vpn, newPPN);
            Console.WriteLine($"VPN {vpn} -> TLB MISS -> PPN {newPPN} (loaded from page table)");
        }
    }

    private int? Lookup(int vpn) {
        foreach (var entry in entries) {
            if (entry.VPN == vpn) return entry.PPN;
        }
        return null;
    }

    private void Insert(int vpn, int ppn) {
        if (entries.Count >= capacity)
            entries.RemoveAt(0);
        entries.Add(new TLBEntry { VPN = vpn, PPN = ppn });
    }

    public void PrintHitRatio() {
        int total = hits + misses;
        double ratio = (double)hits / total * 100;
        Console.WriteLine($"\nTotal: {total} | Hits: {hits} | Misses: {misses}");
        Console.WriteLine($"Hit Ratio: {ratio:F1}%");
    }
}

class Program {
        static void Main() {
            // Page table: VPN -> PPN
            int[] pageTable = { 7, 9, 0, 5, 5, 3, 2, 4, 1, 6, 3, 8, 4, 2, 6, 1 };

            TLB tlb = new TLB();

            Console.WriteLine("=== TLB Simulation ===\n");

         // Sequence of virtual page accesses
            int[] accessSequence = { 0, 1, 2, 3, 0, 1, 6, 2, 3, 0 };

            foreach (int vpn in accessSequence) {
                tlb.Translate(vpn, pageTable);
            }

            tlb.PrintHitRatio();
        }
}