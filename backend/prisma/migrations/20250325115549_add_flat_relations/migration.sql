/*
  Warnings:

  - Added the required column `flatId` to the `Task` table without a default value. This is not possible if the table is not empty.

*/
-- AlterTable
ALTER TABLE "Task" ADD COLUMN     "flatId" TEXT NOT NULL;

-- AlterTable
ALTER TABLE "User" ADD COLUMN     "isInFlat" BOOLEAN NOT NULL DEFAULT false;

-- CreateTable
CREATE TABLE "Flat" (
    "id" TEXT NOT NULL,
    "name" TEXT NOT NULL,
    "inviteCode" TEXT NOT NULL,
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,

    CONSTRAINT "Flat_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "_UserFlats" (
    "A" TEXT NOT NULL,
    "B" TEXT NOT NULL,

    CONSTRAINT "_UserFlats_AB_pkey" PRIMARY KEY ("A","B")
);

-- CreateIndex
CREATE UNIQUE INDEX "Flat_inviteCode_key" ON "Flat"("inviteCode");

-- CreateIndex
CREATE INDEX "_UserFlats_B_index" ON "_UserFlats"("B");

-- AddForeignKey
ALTER TABLE "Task" ADD CONSTRAINT "Task_flatId_fkey" FOREIGN KEY ("flatId") REFERENCES "Flat"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "_UserFlats" ADD CONSTRAINT "_UserFlats_A_fkey" FOREIGN KEY ("A") REFERENCES "Flat"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "_UserFlats" ADD CONSTRAINT "_UserFlats_B_fkey" FOREIGN KEY ("B") REFERENCES "User"("id") ON DELETE CASCADE ON UPDATE CASCADE;
