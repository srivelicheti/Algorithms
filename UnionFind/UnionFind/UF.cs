using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public class UF_QuickFind
    {
        private readonly int _size;
        private int[] _arr;
        private int _connectedComponents;
        public UF_QuickFind(int size) {
            _size = size;
            _arr = new int[size];
            _connectedComponents = size;
            for (int i = 0; i < size; i++)
            {
                _arr[i] = i;
            }
        }

        public void Union(int p, int q) {
            var pID = GetComponentIdentifier(p);
            int qID = GetComponentIdentifier(q);
            if (pID != qID)
            {
                for (int i = 0; i < _arr.Length; i++)
                {
                    if (_arr[i] == pID)
                        _arr[i] = qID;
                }
                _connectedComponents--;
            }
        }

        public int GetComponentIdentifier(int p) {
            return _arr[p];
        }

        public bool Connected(int p, int q) {
            return this.GetComponentIdentifier(p) == this.GetComponentIdentifier(q);
            //throw new NotImplementedException();
        }

        public int ConnectedComponentsCount() {
            return _connectedComponents;
        }
    }

    public class UF_QuickUnion
    {
        private int[] _arr;
        private int _comp;
        private int[] _size;
        public UF_QuickUnion(int size)
        {
            _comp = size;
            _arr = new int[size];
            for (int i = 0; i < size; i++)
                _arr[i] = i;

            _size = new int[size];
            for (int i = 0; i < size; i++)
                _size[i] = 1;
        }

        public void Union(int p, int q)
        {
            int pRoot = Root(p);
            int qRoot = Root(q);
            if (pRoot != qRoot)
            {
                if (_size[qRoot] <_size[pRoot]  )
                {
                    _arr[qRoot] = pRoot;
                    _size[pRoot] += _size[qRoot];
                }
                else //if (_size[pRoot] < _size[qRoot]  )
                {
                    _arr[pRoot] = qRoot;
                    _size[qRoot] += _size[pRoot];
                }
                //else {
                //    _arr[pRoot] = qRoot;
                //    _size[qRoot] = _size[qRoot] + 1;
                //}
            }
            _comp--;
        }

        public int Root(int p)
        {
            while (_arr[p] != p)
                p = _arr[p];
            return p;
        }

        public bool Connected(int p, int q)
        {
            var t = _arr.FirstOrDefault(x => _arr[x] == x);
            return Root(p) == Root(q);
        }

        public int ConnectedCompCount()
        {
            return _comp;
        }
    }
}
