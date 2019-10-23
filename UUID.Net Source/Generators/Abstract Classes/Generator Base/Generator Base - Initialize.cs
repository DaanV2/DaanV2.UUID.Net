﻿/*ISC License

Copyright (c) 2019, Daan Verstraten, daanverstraten@hotmail.com

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.*/
using System;

namespace DaanV2.UUID.Generators {
    /// <summary>The base of a UUID generator</summary>
    public abstract partial class GeneratorBase {
        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        public GeneratorBase() : this((Int32)DateTime.Now.Ticks) { }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="Seed"></param>
        public GeneratorBase(Int32 Seed) : this(new Random(Seed)) { }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="NumberGenerator"></param>
        public GeneratorBase(Random NumberGenerator) {
            this._NumberGenerator = NumberGenerator;
            this._ToHexChars = new Char[,] {
                {'0', '0'}, {'0', '1'}, {'0', '2'}, {'0', '3'},{'0', '4'}, {'0', '5'}, {'0', '6'}, {'0', '7'},
                {'0', '8'}, {'0', '9'}, {'0', 'A'}, {'0', 'B'},{'0', 'C'}, {'0', 'D'}, {'0', 'E'}, {'0', 'F'},
                {'1', '0'}, {'1', '1'}, {'1', '2'}, {'1', '3'},{'1', '4'}, {'1', '5'}, {'1', '6'}, {'1', '7'},
                {'1', '8'}, {'1', '9'}, {'1', 'A'}, {'1', 'B'},{'1', 'C'}, {'1', 'D'}, {'1', 'E'}, {'1', 'F'},
                {'2', '0'}, {'2', '1'}, {'2', '2'}, {'2', '3'},{'2', '4'}, {'2', '5'}, {'2', '6'}, {'2', '7'},
                {'2', '8'}, {'2', '9'}, {'2', 'A'}, {'2', 'B'},{'2', 'C'}, {'2', 'D'}, {'2', 'E'}, {'2', 'F'},
                {'3', '0'}, {'3', '1'}, {'3', '2'}, {'3', '3'},{'3', '4'}, {'3', '5'}, {'3', '6'}, {'3', '7'},
                {'3', '8'}, {'3', '9'}, {'3', 'A'}, {'3', 'B'},{'3', 'C'}, {'3', 'D'}, {'3', 'E'}, {'3', 'F'},
                {'4', '0'}, {'4', '1'}, {'4', '2'}, {'4', '3'},{'4', '4'}, {'4', '5'}, {'4', '6'}, {'4', '7'},
                {'4', '8'}, {'4', '9'}, {'4', 'A'}, {'4', 'B'},{'4', 'C'}, {'4', 'D'}, {'4', 'E'}, {'4', 'F'},
                {'5', '0'}, {'5', '1'}, {'5', '2'}, {'5', '3'},{'5', '4'}, {'5', '5'}, {'5', '6'}, {'5', '7'},
                {'5', '8'}, {'5', '9'}, {'5', 'A'}, {'5', 'B'},{'5', 'C'}, {'5', 'D'}, {'5', 'E'}, {'5', 'F'},
                {'6', '0'}, {'6', '1'}, {'6', '2'}, {'6', '3'},{'6', '4'}, {'6', '5'}, {'6', '6'}, {'6', '7'},
                {'6', '8'}, {'6', '9'}, {'6', 'A'}, {'6', 'B'},{'6', 'C'}, {'6', 'D'}, {'6', 'E'}, {'6', 'F'},
                {'7', '0'}, {'7', '1'}, {'7', '2'}, {'7', '3'},{'7', '4'}, {'7', '5'}, {'7', '6'}, {'7', '7'},
                {'7', '8'}, {'7', '9'}, {'7', 'A'}, {'7', 'B'},{'7', 'C'}, {'7', 'D'}, {'7', 'E'}, {'7', 'F'},
                {'8', '0'}, {'8', '1'}, {'8', '2'}, {'8', '3'},{'8', '4'}, {'8', '5'}, {'8', '6'}, {'8', '7'},
                {'8', '8'}, {'8', '9'}, {'8', 'A'}, {'8', 'B'},{'8', 'C'}, {'8', 'D'}, {'8', 'E'}, {'8', 'F'},
                {'9', '0'}, {'9', '1'}, {'9', '2'}, {'9', '3'},{'9', '4'}, {'9', '5'}, {'9', '6'}, {'9', '7'},
                {'9', '8'}, {'9', '9'}, {'9', 'A'}, {'9', 'B'},{'9', 'C'}, {'9', 'D'}, {'9', 'E'}, {'9', 'F'},
                {'A', '0'}, {'A', '1'}, {'A', '2'}, {'A', '3'},{'A', '4'}, {'A', '5'}, {'A', '6'}, {'A', '7'},
                {'A', '8'}, {'A', '9'}, {'A', 'A'}, {'A', 'B'},{'A', 'C'}, {'A', 'D'}, {'A', 'E'}, {'A', 'F'},
                {'B', '0'}, {'B', '1'}, {'B', '2'}, {'B', '3'},{'B', '4'}, {'B', '5'}, {'B', '6'}, {'B', '7'},
                {'B', '8'}, {'B', '9'}, {'B', 'A'}, {'B', 'B'},{'B', 'C'}, {'B', 'D'}, {'B', 'E'}, {'B', 'F'},
                {'C', '0'}, {'C', '1'}, {'C', '2'}, {'C', '3'},{'C', '4'}, {'C', '5'}, {'C', '6'}, {'C', '7'},
                {'C', '8'}, {'C', '9'}, {'C', 'A'}, {'C', 'B'},{'C', 'C'}, {'C', 'D'}, {'C', 'E'}, {'C', 'F'},
                {'D', '0'}, {'D', '1'}, {'D', '2'}, {'D', '3'},{'D', '4'}, {'D', '5'}, {'D', '6'}, {'D', '7'},
                {'D', '8'}, {'D', '9'}, {'D', 'A'}, {'D', 'B'},{'D', 'C'}, {'D', 'D'}, {'D', 'E'}, {'D', 'F'},
                {'E', '0'}, {'E', '1'}, {'E', '2'}, {'E', '3'},{'E', '4'}, {'E', '5'}, {'E', '6'}, {'E', '7'},
                {'E', '8'}, {'E', '9'}, {'E', 'A'}, {'E', 'B'},{'E', 'C'}, {'E', 'D'}, {'E', 'E'}, {'E', 'F'},
                {'F', '0'}, {'F', '1'}, {'F', '2'}, {'F', '3'},{'F', '4'}, {'F', '5'}, {'F', '6'}, {'F', '7'},
                {'F', '8'}, {'F', '9'}, {'F', 'A'}, {'F', 'B'},{'F', 'C'}, {'F', 'D'}, {'F', 'E'}, {'F', 'F'}
            };
        }
    }
}
