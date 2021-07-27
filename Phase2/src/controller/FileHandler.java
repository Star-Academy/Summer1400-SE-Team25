package controller;

import model.FileMapper;
import model.InvertedIndex;

import java.io.File;
import java.io.IOException;
import java.util.Objects;
import java.util.Scanner;

public class FileHandler {
    private String directoryName;
    private FileMapper fileMapper;

    public FileHandler(String documentPath, FileMapper fileMapper) {
        this.directoryName = documentPath;
        this.fileMapper = fileMapper;
    }

    public void init() {
        File documentsFolder = new File(directoryName);
        for (File file : Objects.requireNonNull(documentsFolder.listFiles()))
            extractWords(file);
    }

    private void extractWords(File file) {
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
