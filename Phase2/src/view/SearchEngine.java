package view;

import controller.FileHandler;
import controller.QueryHandler;
import model.DocumentFile;
import util.Config;

import java.util.HashSet;
import java.util.Scanner;

public class SearchEngine {
    private final FileHandler fileHandler;
    private final QueryHandler queryHandler;
    private final Scanner inputScanner;

    public SearchEngine() {
        fileHandler = new FileHandler(Config.retrieveProperty("ENGLISH_DATA_PATH"));
        queryHandler = new QueryHandler(fileHandler.getInvertedIndex());
        inputScanner = new Scanner(System.in);
    }

    public void start() {
        System.out.println("Enter some words, separated by space: ");
        String input = inputScanner.nextLine();
        HashSet<DocumentFile> resultSet = queryHandler.search(input);
        showResults(resultSet);
        inputScanner.close();

    }

    private void showResults(HashSet<DocumentFile> resultSet) {
        System.out.println("Results: ");
        for (DocumentFile document : resultSet) {
            System.out.println("\t" + document.getFileName());
            System.out.println("\t\t" + document.previewDocument());
        }
    }
}
