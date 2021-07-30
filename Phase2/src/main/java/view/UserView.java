package view;

import java.util.Scanner;

import controller.SearchEngine;

public class UserView {
    private final SearchEngine searchEngine;
    private final Scanner inputScanner;
    private String currentInputLine;

    public UserView(SearchEngine searchEngine){
        this.searchEngine = searchEngine;
        this.inputScanner = new Scanner(System.in);
    }

    public void run() {
        getInput();
        executeSearchCommand();
    }

    private void getInput() {
        System.out.println("Enter search query:\n");
        currentInputLine = inputScanner.nextLine();
    }

    private void executeSearchCommand(){
        System.out.print(searchEngine.search(currentInputLine));
    }
}
