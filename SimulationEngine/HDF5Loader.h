#pragma once

#include <string>
#include <vector>
#include <H5Cpp.h>

class HDF5Loader {
public:
    HDF5Loader(const std::string& coordsFile, const std::string& timeFile, const std::string& tFile, const std::string& mfFile);
    void loadData();

    const std::vector<std::vector<double>>& getCoords() const { return coords; }
    const std::vector<double>& getTime() const { return time; }
    const std::vector<std::vector<double>>& getTemperature() const { return temperature; }
    const std::vector<std::vector<double>>& getMF() const { return mf; }

private:
    std::string coordsFile;
    std::string timeFile;
    std::string tFile;
    std::string mfFile;

    std::vector<std::vector<double>> coords;
    std::vector<double> time;
    std::vector<std::vector<double>> temperature;
    std::vector<std::vector<double>> mf;

    void readCoords();
    void readTime();
    void readTemperature();
    void readMF();
};
