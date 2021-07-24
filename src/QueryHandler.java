import java.util.HashSet;

public class QueryHandler {
    private InvertedIndex invertedIndex;

    public HashSet<Document> search(String query){
        String[] queryList = query.split(" ");
        HashSet<Document> res = new HashSet<>();
        for(String i : queryList){
            String simpleWord = WordUtil.extractRootWord(i);
            res.addAll(invertedIndex.getOccurredDocuments(simpleWord));
        }
        return res;
    }

    public void run() {
    }
}