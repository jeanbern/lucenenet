﻿using System;
using System.Collections.Generic;
using Lucene.Net.Support;
using Lucene.Net.Util;
using NUnit.Framework;
using System.Linq;

namespace Lucene.Net.Test.Util
{
    [TestFixture]
    public class TestBytesRefHash : LuceneTestCase
    {
        private IList<int> CreateRandomList(int maxSize)
        {
            var rnd = new Random();
            var a = new int[rnd.Next(maxSize) + 1];
            for (var i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(a.Length);
            }
            return a.ToList();
        }

        [Test]
        public void TestQuickSort()
        {
            for (int i = 0, c = AtLeast(500); i < c; i++)
            {
                var list1 = CreateRandomList(2000);
                var list2 = new List<int>(list1);
                CollectionUtil.QuickSort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);

                list1 = CreateRandomList(2000);
                list2 = new List<int>(list1);
                CollectionUtil.QuickSort(list1, Collections.ReverseOrder());
                Collections.Sort(list2, Collections.ReverseOrder());
                assertEquals(list2, list1);
                // reverse back, so we can test that completely backwards sorted array (worst case) is working:
                CollectionUtil.QuickSort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);
            }
        }

        [Test]
        public void TestMergeSort()
        {
            for (int i = 0, c = AtLeast(500); i < c; i++)
            {
                var list1 = CreateRandomList(2000);
                var list2 = new List<int>(list1);
                CollectionUtil.MergeSort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);

                list1 = CreateRandomList(2000);
                list2 = new List<int>(list1);
                CollectionUtil.MergeSort(list1, Collections.ReverseOrder());
                Collections.Sort(list2, Collections.ReverseOrder());
                assertEquals(list2, list1);
                // reverse back, so we can test that completely backwards sorted array (worst case) is working:
                CollectionUtil.MergeSort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);
            }
        }

        [Test]
        public void TestTimSort()
        {
            for (int i = 0, c = AtLeast(500); i < c; i++)
            {
                var list1 = CreateRandomList(2000);
                var list2 = new List<int>(list1);
                CollectionUtil.TimSort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);

                list1 = CreateRandomList(2000);
                list2 = new List<int>(list1);
                CollectionUtil.TimSort(list1, Collections.ReverseOrder());
                Collections.Sort(list2, Collections.ReverseOrder());
                assertEquals(list2, list1);
                // reverse back, so we can test that completely backwards sorted array (worst case) is working:
                CollectionUtil.TimSort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);
            }
        }

        [Test]
        public void TestInsertionSort()
        {
            for (int i = 0, c = AtLeast(500); i < c; i++)
            {
                var list1 = CreateRandomList(30);
                var list2 = new List<int>(list1);
                CollectionUtil.InsertionSort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);

                list1 = CreateRandomList(30);
                list2 = new List<int>(list1);
                CollectionUtil.InsertionSort(list1, Collections.ReverseOrder());
                Collections.Sort(list2, Collections.ReverseOrder());
                assertEquals(list2, list1);
                // reverse back, so we can test that completely backwards sorted array (worst case) is working:
                CollectionUtil.InsertionSort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);
            }
        }

        [Test]
        public void TestBinarySort()
        {
            for (int i = 0, c = AtLeast(500); i < c; i++)
            {
                var list1 = CreateRandomList(30);
                var list2 = new List<int>(list1);
                CollectionUtil.BinarySort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);

                list1 = CreateRandomList(30);
                list2 = new List<int>(list1);
                CollectionUtil.BinarySort(list1, Collections.ReverseOrder());
                Collections.Sort(list2, Collections.ReverseOrder());
                assertEquals(list2, list1);
                // reverse back, so we can test that completely backwards sorted array (worst case) is working:
                CollectionUtil.BinarySort(list1);
                Collections.Sort(list2);
                assertEquals(list2, list1);
            }
        }

        [Test]
        public void TestEmptyListSort()
        {
            // should produce no exceptions
            IList<int> list = new int[0].ToList(); // LUCENE-2989
            CollectionUtil.QuickSort(list);
            CollectionUtil.MergeSort(list);
            CollectionUtil.TimSort(list);
            CollectionUtil.InsertionSort(list);
            CollectionUtil.BinarySort(list);
            CollectionUtil.QuickSort(list, Collections.ReverseOrder());
            CollectionUtil.MergeSort(list, Collections.ReverseOrder());
            CollectionUtil.TimSort(list, Collections.ReverseOrder());
            CollectionUtil.InsertionSort(list, Collections.ReverseOrder());
            CollectionUtil.BinarySort(list, Collections.ReverseOrder());

            // check that empty non-random access lists pass sorting without ex (as sorting is not needed)
            list = new LinkedList<int>();
            CollectionUtil.QuickSort(list);
            CollectionUtil.MergeSort(list);
            CollectionUtil.TimSort(list);
            CollectionUtil.InsertionSort(list);
            CollectionUtil.BinarySort(list);
            CollectionUtil.QuickSort(list, Collections.ReverseOrder());
            CollectionUtil.MergeSort(list, Collections.ReverseOrder());
            CollectionUtil.TimSort(list, Collections.ReverseOrder());
            CollectionUtil.InsertionSort(list, Collections.ReverseOrder());
            CollectionUtil.BinarySort(list, Collections.ReverseOrder());
        }

        [Test]
        public void TestOneElementListSort()
        {
            // check that one-element non-random access lists pass sorting without ex (as sorting is not needed)
            IList<int> list = new LinkedList<int>();
            list.Add(1);
            CollectionUtil.QuickSort(list);
            CollectionUtil.MergeSort(list);
            CollectionUtil.TimSort(list);
            CollectionUtil.InsertionSort(list);
            CollectionUtil.BinarySort(list);
            CollectionUtil.QuickSort(list, Collections.ReverseOrder());
            CollectionUtil.MergeSort(list, Collections.ReverseOrder());
            CollectionUtil.TimSort(list, Collections.ReverseOrder());
            CollectionUtil.InsertionSort(list, Collections.ReverseOrder());
            CollectionUtil.BinarySort(list, Collections.ReverseOrder());
        }
    }
}