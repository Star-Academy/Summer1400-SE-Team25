package controller;

import model.InvertedIndex;

import java.io.File;
import java.io.IOException;
import java.util.Objects;
import java.util.Scanner;

public class FileHandler {
    private String directoryName;
    private InvertedIndex invertedIndex;

    public FileHandler(String documentPath, InvertedIndex invertedIndex) {
        this.directoryName = documentPath;
        this.invertedIndex = invertedIndex;
        init();
    }

    private void init() {
        File documentsFolder = new File(directoryName);
        for (File file : Objects.requireNonNull(documentsFolder.listFiles()))
            extractWords(file);
    }

    private void extractWords(File file) {
        invertedIndex.addDocument(file);
        try (Scanner fileScanner = new Scanner(file)) {
            while (fileScanner.hasNextLine()) {
                String readWord = fileScanner.next();
//                invertedIndex.addWord(file, readWord);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
