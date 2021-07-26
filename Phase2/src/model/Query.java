package model;

import java.util.HashSet;

public abstract class Query {
    protected String queryString;
    protected InvertedIndex index;

    public abstract HashSet<DocumentFile> pushSearchResult(HashSet<DocumentFile> prevSearhcResult);
}
