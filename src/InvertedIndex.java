import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

/**
 * document -> index
 * hashmap: word, list[index]
 */
public class InvertedIndex {
    private final HashMap<String, HashSet<Document>> invertedList;
    private final ArrayList<Document> documentList;

    public InvertedIndex() {
        invertedList = new HashMap<>();
        documentList = new ArrayList<>();
    }

    public void addWord(String word, Document document) {
        if (!invertedList.containsKey(word))
            invertedList.put(word, new HashSet<>());
        invertedList.get(word).add(document);
    }

    public void addDocument(Document document) {
        documentList.add(document);
    }

    public int getDocumentCount() {
        return documentList.size();
    }
}
