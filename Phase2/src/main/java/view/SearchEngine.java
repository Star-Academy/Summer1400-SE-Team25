package view;

import java.util.Scanner;
import java.util.Set;

import controller.QueryHandler;
import model.DocumentFile;

public class SearchEngine {
    private final QueryHandler queryHandler;
    private final Scanner inputScanner;

    public SearchEngine(QueryHandler queryHandler) {
        this.queryHandler = queryHandler;
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
