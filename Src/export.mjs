/**
 * Wihler Ruben
 * TPI 2024 - FruitPower
 * Script utilitaire pour exporter le code source du projet dans un fichier markdown temporaire pour le copier-coller dans le rapport
 */

import * as fs from 'fs';
import * as path from 'path';

const basePath = './Src/FruitPower/Assets/Scripts/';
const exportPath = './export.md';

const files = [
    'FruitSystem/FruitTypeData.cs',
    'FruitSystem/FruitTypesDatas.cs',
    'FruitSystem/Fruit.cs',
    'FruitSystem/FruitState.cs',
    'FruitSystem/FruitManager.cs',
    'FruitSystem/FruitPoolData.cs',
    'FruitSystem/FruitPooler.cs',
    'FruitSystem/FruitSpawnManager.cs',
    'FruitSystem/FruitSpawner.cs',
    'FruitSystem/Basket.cs',

    'GameManagement/GameOption.cs',
    'GameManagement/GameManager.cs',
    'GameManagement/GameScore.cs',
    'GameManagement/GameStats.cs',
    'GameManagement/GameTimer.cs',

    'UI/UIManager.cs',
    'UI/ScoreVisualizer.cs',
    'UI/StatsVisualizer.cs',
    'UI/TimerVisualizer.cs',
    'UI/CaughtFruitElement.cs',
    'UI/Countdown.cs',
    'UI/GameEndText.cs',
    'UI/PlayButton.cs',
    'UI/QuitButton.cs',
    'UI/Credits.cs',

    'Audio/MusicManager.cs',
    'Audio/Radio.cs',

    'Extensions/AudioExtensions.cs',

    'Inputs/HandController.cs',
];

const exportFile = fs.createWriteStream(exportPath);

exportFile.write('# Code source du projet FruitPower\n\n');

files.forEach((file) => {
    const filePath = path.join(basePath, file);
    const fileName = file.split('/').pop();
    const fileContent = fs.readFileSync(filePath, 'utf8');

    exportFile.write(`## ${fileName}\n\n`);
    exportFile.write(`\`\`\`csharp file=${fileName}\n`);
    exportFile.write(fileContent);
    exportFile.write('\n```\n\n');
});

exportFile.end();
