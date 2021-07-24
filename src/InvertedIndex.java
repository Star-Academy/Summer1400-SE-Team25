import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

/**
 * document -> index
 * hashmap: word, list[index]
 */
public class InvertedIndex {
    private final HashMap<String, HashSet<Document>> invertedList;
    private int documentCount;

    public InvertedIndex() {
        invertedList = new HashMap<>();
        documentCount = 0;
    }

    public void addWord(String word, Document document) {
        if (!invertedList.containsKey(word))
            invertedList.put(word, new HashSet<>());
        invertedList.get(word).add(document);
    }

    public void incrementDocumentCount() {
        documentCount++;
    }

    public int getDocumentCount() {
        return documentCount;
    }
}
