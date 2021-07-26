package model.query;

import model.DocumentFile;
import model.InvertedIndex;

import java.util.HashSet;

public abstract class Query {
    protected String queryString;
    protected InvertedIndex index;

    public abstract HashSet<DocumentFile> pushSearchResult(HashSet<DocumentFile> prevSearchResult);
}
