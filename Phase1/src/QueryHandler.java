import java.io.FileReader;
import java.io.IOException;
import java.util.HashSet;
import java.util.Scanner;

import javax.swing.text.Document;

public class QueryHandler {
    private InvertedIndex invertedIndex;

    public QueryHandler(InvertedIndex invertedIndex) {
        this.invertedIndex = invertedIndex;
    }

    public HashSet<Document> search(String query) {
        String[] queryList = query.split(" ");
        HashSet<Document> res = new HashSet<Document>(invertedIndex.getDocuments());
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
            System.out.print("\t\t" + documentPreview(i) + "\n");
        }
    }

    private String documentPreview(Document doc) {
        StringBuilder res = new StringBuilder();
        int counter = 27;
        try (Scanner docSc = new Scanner(new FileReader(doc.getFile()))) {
            String temp = docSc.nextLine();
            res.append(temp.substring(0, Math.min(temp.length(), 27)));
            res.append("...");
        } catch (IOException e) {
            e.printStackTrace();
        }
        return res.toString();
    }
}