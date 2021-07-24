import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

/**
 * document -> index
 * hashmap: word, list[index]
 */
public class InvertedIndex {
    private final HashMap<String, HashSet<Integer>> invertedList;
    private final HashMap<String, Integer> documentList;

    public InvertedIndex() {
        invertedList = new HashMap<>();
        documentList = new HashMap<>();
    }

    public void addWord(String word, int documentIndex) {
        if (!invertedList.containsKey(word))
            invertedList.put(word, new HashSet<>());
        invertedList.get(word).add(documentIndex);
    }

    public int getDocumentIndex(String document) {
        if (!documentList.containsKey(document))
            throw new IllegalArgumentException("No such document found!");
        return documentList.get(document);
    }

    public void addDocumentToList(String document) {
        if (documentList.containsKey(document))
            throw new IllegalArgumentException("Duplicate document key.");
        documentList.put(document, documentList.size());
    }
}
