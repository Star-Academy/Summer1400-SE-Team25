import java.io.File;
import java.io.IOException;
import java.util.Scanner;

public class FileHandler {
    private String dirName;
    private InvertedIndex invertedIndex;

    public FileHandler(String documentPath) {
        this.dirName = documentPath;
        invertedIndex = new InvertedIndex();
        init();
    }

    public InvertedIndex getInvertedIndex() {
        return invertedIndex;
    }

    private void init() {
        File documentsFolder = new File(dirName);
        for (File file : documentsFolder.listFiles())
            extractWords(file);
    }

    private void extractWords(File file) {
        Document newDocument = new Document(file.getName(), invertedIndex.getDocumentCount());
        invertedIndex.addDocument(newDocument);
        try (Scanner fileScanner = new Scanner(file)) {
            while (fileScanner.hasNext()) {
                String readWord = WordUtil.extractRootWord(fileScanner.next());
                if (readWord != null)
                    invertedIndex.addWord(readWord, newDocument);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
