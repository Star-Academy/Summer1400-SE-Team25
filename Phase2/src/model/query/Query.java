package model.query;

import java.util.HashSet;

import model.DocumentFile;
import model.InvertedIndex;

public abstract class Query {
    protected String queryString;
    protected InvertedIndex index;

    public Query(InvertedIndex index, String queryString){
        this.index = index;
        this.queryString = queryString;
    }

    public abstract HashSet<DocumentFile> pushSearchResult(HashSet<DocumentFile> prevSearchResult);

    public static Query getNewInstance(String queryString, InvertedIndex index){
        if(queryString.charAt(0) == '+')
            return new ORQuery(queryString, index);
        else if(queryString.charAt(0) == '-')
            return new NOTQuery(queryString, index);
        return new ANDQuery(queryString, index);
    }
}
