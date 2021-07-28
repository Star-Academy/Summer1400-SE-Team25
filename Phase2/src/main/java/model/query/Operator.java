package model.query;

import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;

public abstract class Operator {
    protected String queryString;
    protected InvertedIndex index;

    public Operator(InvertedIndex index, String queryString){
        this.index = index;
        this.queryString = queryString;
    }

    public abstract Set<DocumentFile> pushSearchResult(Set<DocumentFile> prevSearchResult);

    public static Operator getNewInstance(String queryString, InvertedIndex index){
        if(queryString.charAt(0) == '+')
            return new OROperator(queryString, index);
        else if(queryString.charAt(0) == '-')
            return new NOTOperator(queryString, index);
        return new ANDOperator(queryString, index);
    }
}
