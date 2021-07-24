import java.util.HashSet;
import java.util.Scanner;

public class QueryHandler {
    private InvertedIndex invertedIndex;

    public QueryHandler(InvertedIndex invertedIndex) {
        this.invertedIndex = invertedIndex;
    }

    public HashSet<Document> search(String query) {
        String[] queryList = query.split(" ");
        HashSet<Document> res = new HashSet<>(invertedIndex.getDocuments());
        for (String i : queryList) {
            if ((i.charAt(0) != '+') && (i.charAt(0) != '-')) {
                String simpleWord = WordUtil.extractRootWord(i);
                if (simpleWord != null)
                    res.retainAll(invertedIndex.getOccurredDocuments(simpleWord));
            }

        }
        for (String i : queryList) {
            if (i.charAt(0) == '+') {
                String simpleWord = WordUtil.extractRootWord(i);
                if (simpleWord != null)
                    res.addAll(invertedIndex.getOccurredDocuments(simpleWord));
            }
        }
        for (String i : queryList) {
            if (i.charAt(0) == '-') {
                String simpleWord = WordUtil.extractRootWord(i);
                if (simpleWord != null)
                    res.removeAll(invertedIndex.getOccurredDocuments(simpleWord));
            }
        }
        return res;
    }

    public void run() {
        Scanner sc = new Scanner(System.in);
        String cmdLine = sc.nextLine();
        HashSet<Document> srchRes = search(cmdLine);
        System.out.print("Result : \n");
        for (Document i : srchRes) {
            System.out.print("\t" + i.getFileName() + "\n");
        }
    }
}