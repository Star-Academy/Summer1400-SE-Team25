package controller;

import java.util.*;

import model.DocumentFile;
import model.InvertedIndex;
import model.query.ANDQuery;
import model.query.NOTQuery;
import model.query.ORQuery;
import model.query.Query;

public class QueryHandler {
    private InvertedIndex invertedIndex;
    private ArrayList<Query> queriesList;

    public QueryHandler(InvertedIndex invertedIndex) {
        this.invertedIndex = invertedIndex;
        queriesList = new ArrayList<>();
    }

    public HashSet<DocumentFile> search(String query) {
        setQueryList(query);
        sortQueryList();
        HashSet<DocumentFile> res = new HashSet<>(invertedIndex.getDocuments());
        for(Query i : queriesList)
            res = i.pushSearchResult(res);
        return res;
    }

    /**
     * sort the queries list so that every ANDQuery will be computed before every ORQuery
     * and every ORQuery will be computed before every NOTQuery
     */
    private void sortQueryList() {
        Collections.sort(queriesList, (o1, o2) -> {
            if (o1 instanceof ANDQuery) // o1 is ANDQuery
                return (o2 instanceof ANDQuery? 0: -1);
            else if (o2 instanceof ANDQuery) // o2 is ANDQuery and o1 either is ORQuery or NOTQuery
                return 1;
            else if (o1 instanceof ORQuery) // o1 is ORQuery and o2 isn't ANDQuery
                return (o2 instanceof ORQuery? 0: -1);
            else // o1 is NOTQuery
                return (o2 instanceof NOTQuery? 0: 1);
        });
    }

    private void setQueryList(String query) {
        String[] subQueries = query.split(" ");
        for (String i : subQueries)
            queriesList.add(Query.getNewInstance(i, invertedIndex));
    }
}