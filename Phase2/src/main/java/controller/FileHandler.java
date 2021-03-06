package controller;

import java.io.File;
import java.io.IOException;
import java.util.Objects;
import java.util.Scanner;

import model.FileMapper;
import model.InvertedIndex;

public class FileHandler {
    private final FileMapper fileMapper;

    public FileHandler(InvertedIndex invertedIndex){
        this.fileMapper = new FileMapper(invertedIndex);
    }

    public void initialize(String directoryName) {
        var documentsFolder = new File(directoryName);
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
