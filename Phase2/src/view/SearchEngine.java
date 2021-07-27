package view;

import controller.FileHandler;
import controller.QueryHandler;
import model.DocumentFile;
import model.FileMapper;
import model.InvertedIndex;
import util.Config;

import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class SearchEngine {
    private final QueryHandler queryHandler;
    private final Scanner inputScanner;

    public SearchEngine() {
        InvertedIndex invertedIndex = new InvertedIndex();
        FileMapper fileMapper = new FileMapper(invertedIndex);
        FileHandler fileHandler = new FileHandler(Config.retrieveProperty("ENGLISH_DATA_PATH"), fileMapper);
        fileHandler.init();
        queryHandler = new QueryHandler(invertedIndex);
        inputScanner = new Scanner(System.in);
    }

    public void start() {
        System.out.println("Enter some words, separated by space: ");
        String input = inputScanner.nextLine();
        Set<DocumentFile> resultSet = queryHandler.search(input);
        showResults(resultSet);
        inputScanner.close();

    }

    private void showResults(Set<DocumentFile> resultSet) {
        System.out.println("Results: ");
        for (DocumentFile document : resultSet) {
            System.out.println("\t" + document.getFileName());
            System.out.println("\t\t" + document.previewDocument());
        }
    }
}
