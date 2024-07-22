#include "HDF5Loader.h"

HDF5Loader::HDF5Loader(const std::string& coordsFile, const std::string& timeFile, const std::string& tFile, const std::string& mfFile)
    : coordsFile(coordsFile), timeFile(timeFile), tFile(tFile), mfFile(mfFile) {}

void HDF5Loader::loadData() {
    readCoords();
    readTime();
    readTemperature();
    readMF();
}

void HDF5Loader::readCoords() {
    H5::H5File file(coordsFile, H5F_ACC_RDONLY);
    H5::DataSet dataset = file.openDataSet("coords");
    H5::DataSpace dataspace = dataset.getSpace();

    hsize_t dims[2];
    dataspace.getSimpleExtentDims(dims, NULL);
    coords.resize(dims[0], std::vector<double>(dims[1]));

    dataset.read(coords.data(), H5::PredType::NATIVE_DOUBLE);
}

void HDF5Loader::readTime() {
    H5::H5File file(timeFile, H5F_ACC_RDONLY);
    H5::DataSet dataset = file.openDataSet("time");
    H5::DataSpace dataspace = dataset.getSpace();

    hsize_t dims[1];
    dataspace.getSimpleExtentDims(dims, NULL);
    time.resize(dims[0]);

    dataset.read(time.data(), H5::PredType::NATIVE_DOUBLE);
}

void HDF5Loader::readTemperature() {
    H5::H5File file(tFile, H5F_ACC_RDONLY);
    H5::DataSet dataset = file.openDataSet("T");
    H5::DataSpace dataspace = dataset.getSpace();

    hsize_t dims[2];
    dataspace.getSimpleExtentDims(dims, NULL);
    temperature.resize(dims[0], std::vector<double>(dims[1]));

    dataset.read(temperature.data(), H5::PredType::NATIVE_DOUBLE);
}

void HDF5Loader::readMF() {
    H5::H5File file(mfFile, H5F_ACC_RDONLY);
    H5::DataSet dataset = file.openDataSet("MF");
    H5::DataSpace dataspace = dataset.getSpace();

    hsize_t dims[2];
    dataspace.getSimpleExtentDims(dims, NULL);
    mf.resize(dims[0], std::vector<double>(dims[1]));

    dataset.read(mf.data(), H5::PredType::NATIVE_DOUBLE);
}
