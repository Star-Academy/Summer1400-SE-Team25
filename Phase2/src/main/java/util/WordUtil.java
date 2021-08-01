package util;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Scanner;

import org.tartarus.snowball.ext.PorterStemmer;

public class WordUtil {
    private static List<String> stopWords;
    private final static String STOP_WORDS_PATH = "src/main/java/StopWords.txt";

    public WordUtil() {
        stopWords = new ArrayList<>();
        initStopWords();
    }

    public String extractRootWord(String word){
        word = word.toLowerCase();
        PorterStemmer stemmer = new PorterStemmer();
        stemmer.setCurrent(word);
        stemmer.stem();
        word = stemmer.getCurrent();
        if (isStopWord(word))
            return null;
        return word;
    }

    private boolean isStopWord(String word) {
        return stopWords.contains(word);
    }

    private void initStopWords() {
        try (Scanner fileScanner = new Scanner(new File(STOP_WORDS_PATH))) {
            while (fileScanner.hasNext())
                stopWords.add(fileScanner.nextLine());
        }
        catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}
