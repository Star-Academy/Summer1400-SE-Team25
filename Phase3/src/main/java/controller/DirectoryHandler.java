package controller;

import model.DocumentFile;

import java.io.File;
import java.util.List;
import java.util.Objects;

public class DirectoryHandler {
    FileHandler fileHandler;

    public DirectoryHandler(FileHandler fileHandler) {
        this.fileHandler = fileHandler;
    }

    public void addAllDocumentsInDirectoryToInvertedIndex(String directoryPath) {
        var listOfFiles = new File(directoryPath).listFiles();
        for (var file : Objects.requireNonNull(listOfFiles))
            fileHandler.addWordsToInvertedIndex(file);
    }
}
