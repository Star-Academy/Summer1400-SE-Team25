package controller;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import model.DocumentFile;
import model.InvertedIndex;
import model.query.ANDOperator;
import model.query.NOTOperator;
import model.query.OROperator;
import model.query.Operator;
import util.WordUtil;

public class QueryHandler {
    private final InvertedIndex invertedIndex;
    private final List<Operator> queriesList;
    private final char orSymbol = '+';
    private final char notSymbol = '-';

    public QueryHandler(InvertedIndex invertedIndex) {
        this.invertedIndex = invertedIndex;
        queriesList = new ArrayList<>();
    }

    public Set<DocumentFile> search(String line, WordUtil wordUtil) {
        setQueryList(line);
        Set<DocumentFile> resultSet = new HashSet<>(invertedIndex.getDocuments());
        for (Operator query : queriesList)
            resultSet = query.operate(resultSet, wordUtil);
        return resultSet;
    }

    private void setQueryList(String query) {
        String[] subQueries = query.split("\\s+");
        for (String subQuery : subQueries)
            queriesList.add(getNewInstance(subQuery, invertedIndex));
    }

    private Operator getNewInstance(String queryString, InvertedIndex index){
        if(queryString.charAt(0) == orSymbol)
            return new OROperator(queryString, index);
        else if(queryString.charAt(0) == notSymbol)
            return new NOTOperator(queryString, index);
        return new ANDOperator(queryString, index);
    }
}