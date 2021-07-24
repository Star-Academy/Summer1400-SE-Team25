import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

public class FileHandler {
    private String dirName;
    private InvertedIndex invertedIndex;

    public FileHandler(String documentPath) {
        this.dirName = documentPath;
        init();
    }

    private void init() {
        File documentsFolder = new File(dirName);
        for (File file : documentsFolder.listFiles())
            extractWords(file);
    }

    private void extractWords(File file) {
        Document newDocument = new Document(file.getName(), invertedIndex.getDocumentCount());
        invertedIndex.addDocument(newDocument);
        try (FileReader fileReader = new FileReader(file)) {
            Scanner fileScanner = new Scanner(fileReader);
            while (fileScanner.hasNext()) {
                String readWord = WordUtil.extractRootWord(fileScanner.next());
                invertedIndex.addWord(readWord, newDocument);
            }
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }
}
