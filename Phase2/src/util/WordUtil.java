package util;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class WordUtil {
    private static List<String> stopWords = new ArrayList<>();

    public static String extractRootWord(String word){
        word = word.toLowerCase();
        word = removeSymbols(word);
        if (isStopWord(word))
            return null;
        return word;
    }

    private static String removeSymbols(String word) {
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < word.length(); i++) {
            if (Character.isAlphabetic(word.charAt(i)))
                res.append(word.charAt(i));
        }
        return res.toString();
    }

    private static boolean isStopWord(String word) {
        if (stopWords.size() == 0)
            initStopWords();
        return stopWords.contains(word);
    }

    private static void initStopWords() {
        try (Scanner fileScanner = new Scanner(new File(Config.retrieveProperty("STOP_WORDS_PATH")))) {
            while (fileScanner.hasNext())
                stopWords.add(fileScanner.nextLine());
        }
        catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}
