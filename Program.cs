using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. 
namespace UAS_024
{
    class Node
    {
        public int Nomor;
        public string Judul;
        public string Nama;
        public int Tahun;
        public Node next;
    }

    class list
    {
        Node START;

        public list()
        {
            START = null;
        }

        public void insert()
        {
            int no, th;
            string nm, jd;
            Console.Write("Masukkan Nomor Buku     : ");
            no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Pengarang : ");
            nm = Console.ReadLine();
            Console.Write("Masukan Tahun Terbit    : ");
            th = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Judul Buku     : ");
            jd = Console.ReadLine();

            Node newnode = new Node();

            newnode.Nomor = no;
            newnode.Nama = nm;
            newnode.Tahun = th;
            newnode.Judul = jd;

            if (START == null || no <= START.Nomor)
            {
                if ((START != null) && (no == START.Nomor))
                {
                    Console.WriteLine("Data yang sama tidak di perbolehkan!");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (no >= current.Nomor))
            {
                if (no == current.Nomor)
                {
                    Console.WriteLine("\nData yang sama tidak diperbolehkan!\n");
                    return ;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool search(int th, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;


            while ((current != null) && (th != current.Tahun))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);

        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nList Data Buku : ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write("Nomor Buku : " + currentNode.Nomor + "    " + "Nama Pengarang : " + currentNode.Nama + "    " + "Tahun Terbit : " + currentNode.Tahun + "         " + "Judul Buku : " + currentNode.Judul + "\n");
                }
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Masukkan Data ke Dalam List");
                    Console.WriteLine("2. Lihat Semua Data Dalam List");
                    Console.WriteLine("3. Cari Data Dalam List");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nMasukan Pilihan Mu (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insert();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukan Tahun Terbit Buku Yang Ingin Dicari : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nData Tidak Ketemu");
                                else
                                {
                                    Node TH;
                                    for (TH = current; TH != null; TH = TH.next)
                                    {
                                        Console.WriteLine("\nData Ditemukan");
                                        Console.WriteLine("\nNomor Buku     : " + current.Nomor);
                                        Console.WriteLine("\nTahun Terbit   : " + current.Tahun);
                                        Console.WriteLine("\nNama Pengarang : " + current.Nama);
                                        Console.WriteLine("\nJudul Buku     : " + current.Judul);
                                    }
                                }
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nMasukan Opsi yang Benar!");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.Write("\nLihat Kembali Data yang Anda Masukan");
                }
            }
        }
    }
}

/*
 * 2. Singly Linked List, karena node nya saling terhubung dan memiliki 1(satu) arah, sehingga akan lebih mudah untuk mencari data
 * 3. Push and Pop
 * 4. Front, Rear
 * 5. a. (5)
 *    b. (Inroder [1,5,8,10,12,15,20,22,25,28,30,36,38,40,45,48,50])
 */
