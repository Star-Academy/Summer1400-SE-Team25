package controller;

import java.io.File;
import java.io.IOException;
import java.util.Objects;
import java.util.Scanner;

import model.FileMapper;
import model.InvertedIndex;

public class FileHandler {
    private final String directoryName;
    private final FileMapper fileMapper;
    final static String DEFAULT_PATH = "src/main/java/EnglishData";

    public FileHandler(InvertedIndex invertedIndex){
        this.directoryName = DEFAULT_PATH;
        this.fileMapper = new FileMapper(invertedIndex);
    }

    public FileHandler(String documentPath, FileMapper fileMapper) {
        this.directoryName = documentPath;
        this.fileMapper = fileMapper;
    }

    public void initialize() {
        File documentsFolder = new File(directoryName);
        for (File file : Objects.requireNonNull(documentsFolder.listFiles()))
            extractWords(file);
    }

    private void extractWords(File file) {
        fileMapper.addDocument(file);
        try (Scanner fileScanner = new Scanner(file)) {
            while (fileScanner.hasNext()) {
                String readWord = fileScanner.next();
                fileMapper.addWordToInvertedIndex(file.getName(), readWord);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
