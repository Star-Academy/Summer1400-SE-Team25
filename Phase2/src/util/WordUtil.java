package util;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

import org.tartarus.snowball.ext.PorterStemmer;

public class WordUtil {
    private static ArrayList<String> stopWords = new ArrayList<>();

    public static String extractRootWord(String word){
        PorterStemmer stemmer = new PorterStemmer();
        stemmer.setCurrent(word);
        stemmer.stem();
        word = stemmer.getCurrent();
        if (isStopWord(word))
            return null;
        return word;
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
