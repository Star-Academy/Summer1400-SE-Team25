using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SearchLib.Model
{
    public class DocumentFileComparator : IEqualityComparer<IDocument>
    {
        public bool Equals([AllowNull] IDocument x, [AllowNull] IDocument y)
        {
            return x.DocumentPath == y.DocumentPath &&
                    x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] IDocument obj)
        {
            return obj.DocumentPath.GetHashCode() ^ obj.Name.GetHashCode();
        }
    }
}
