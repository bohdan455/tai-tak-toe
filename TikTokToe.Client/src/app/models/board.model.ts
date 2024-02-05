export interface Board {
  winner: string | null;
  nextPlayerMove: string;
  cells: {
    value: number;
    row: number;
    column: number;
  }[];
}
