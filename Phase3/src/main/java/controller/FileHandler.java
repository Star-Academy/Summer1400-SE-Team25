package controller;

import model.FileMapper;
import model.InvertedIndex;

import java.io.File;
import java.io.IOException;
import java.util.Scanner;

public class FileHandler {
    private FileMapper fileMapper;
    private InvertedIndex invertedIndex;

    public FileHandler(FileMapper fileMapper, InvertedIndex invertedIndex) {
        this.fileMapper = fileMapper;
        this.invertedIndex = invertedIndex;
    }

    public void addWordsToInvertedIndex(File file) {
        var documentFile = fileMapper.getCorrespondingDocument(file);
        try (Scanner fileScanner = new Scanner(file)) {
            while (fileScanner.hasNext()) {
                var readWord = fileScanner.next();
                invertedIndex.addWord(documentFile, readWord);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
