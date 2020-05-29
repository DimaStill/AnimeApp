export class Manga {
    id: number;
    name: string;
    releaseDate: Date;
    volume: number;
    releaseContinues: boolean;
    translater: string;
    genreIds: Array<number>;
    author: string;
    photoBase64: string;
}